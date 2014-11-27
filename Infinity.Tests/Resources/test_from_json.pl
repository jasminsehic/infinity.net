#!/usr/bin/perl -w

use strict;
use JSON;

my $modelName = "obj";

if ($#ARGV < 0) {
	*IN = *STDIN;
} elsif ($#ARGV == 0) {
	open(IN, $ARGV[0]) || die "$0: could not open $ARGV[0]: $!\n";

	$modelName = $ARGV[0];
	$modelName =~ s/\.json$//;
	$modelName =~ s/.*\.//;
	$modelName =~ s/^Get//;
	$modelName =~ s/^([A-Z])/\l$1/;
} else {
	die "usage: $0 [json_file]\n";
}

my $json = JSON->new->allow_nonref;
my $data = $json->decode(join('', <IN>));

tests_for($modelName, $data);

close(IN);

sub tests_for
{
	my($ctx, $data) = @_;

	if (!defined($data)) {
		print "Assert.Null($ctx);\n";
	} elsif (ref($data) eq 'HASH') {
		if ($data->{'count'} && ref($data->{'value'}) eq 'ARRAY') {
			tests_for_array($ctx, $data->{'value'});
		} else {
			tests_for_hash($ctx, $data);
		}
	} elsif (ref($data) eq 'ARRAY') {
		tests_for_array($ctx, $data);
	} else {
		if ($data =~ /^[a-zA-Z0-9]{8}-[a-zA-Z0-9]{4}-[a-zA-Z0-9]{4}-[a-zA-Z0-9]{4}-[a-zA-Z0-9]{12}$/) {
			$data = 'new Guid("' . $data . '")';
		} elsif ($data =~ /^([0-9]{4})-([0-9]{2})-([0-9]{2})T([0-9]{2}):([0-9]{2}):([0-9]{2})(?:\.([0-9]+))?Z$/) {
			my $t = defined($7) && $7 ?
				($7 < 100 ? ($7 < 10 ? $7 * 100 : $7 * 10) : $7) : 0;
			$data = "new DateTime($1, $2, $3, $4, $5, $6, $t" .
				", DateTimeKind.Utc)";
		} elsif ($data =~ m.^http://. || $data =~ m.^https://.) {
			$data = 'new Uri("' . $data . '")';
		} elsif ($data !~ /^[0-9]+$/ &&
			$data ne 'true' && $data ne 'false') {
			$data =~ s/\\/\\\\/g;
			$data = '"' . $data . '"';
		}

		print "Assert.Equal($data, $ctx);\n";
	}
}

sub tests_for_hash
{
	my ($ctx, $data) = @_;

	foreach my $k (sort(keys(%$data))) {
		my $key = $k;
		my $val = $data->{$k};

		$key =~ s/^([a-z])/\u$1/;

		my $ctx_key = "${ctx}.${key}";

		tests_for($ctx_key, $val);
	}
}

sub tests_for_array
{
	my ($ctx, $data) = @_;

	my $len = @$data;
	print "Assert.Equal($len, $ctx.Count);\n";
	print "\n";

	for (my $i = 0; $i < $len; $i++) {
		my $ctx_i = "${ctx}[$i]";

		tests_for($ctx_i, $data->[$i]);
		print "\n";
	}
}
