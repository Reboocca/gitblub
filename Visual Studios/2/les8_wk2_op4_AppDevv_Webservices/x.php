<?php                                         // # x.php
	$y=$_REQUEST["y"];
	$namen="";

	$db = mysqli_connect('localhost','root','','voornamen');

	$sql = "select naam from namen where naam like '".$y."%'";
	$res = mysqli_query($db, $sql);

	while (list($n) = mysqli_fetch_row($res)) $namen .= $n."<br/> ";
	echo $namen;
?>