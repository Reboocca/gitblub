<?php
//Variabelen voor de connectie met de database
$server = "localhost";
$user = "root";
$pwd = "";
$database = "owl-learn";

//Connectie maken met de database + error afhandeling
if(!($conn = @mysqli_connect($server, $user, $pwd, $database)))
  die ("Error ". mysqli_errno($conn) . " : " . mysqli_error($conn));
?>