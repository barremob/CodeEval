<?php
/*
 * Score: 100
 * Time: 38
 * Memory: 3403687
 * Points: 32.090
 */

echo dirname(__FILE__);
//$fh = fopen ( $argv [1], "r" );
$fh = fopen ("../InputData/Easy/JsonMenuIds.txt", "r");
while ( true ) {
	$test = fgets ( $fh );
	if ($test == null || $test == "") {
		break;
	}
	
	$jsonData = json_decode($test, true);
	$counter = 0;
	
	foreach ($jsonData['menu']['items'] as $key=>$val){
		if($val['label'] != null){
			$counter += $val['id'];
		}
	}
	echo $counter . "\n";
}
?>