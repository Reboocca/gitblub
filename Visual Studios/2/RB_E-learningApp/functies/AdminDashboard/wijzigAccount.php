<?php
    $server = "localhost";
    $user = "root"; 
    $pwd = "";
    $database = "owl-learn";
    
    $aID = $_REQUEST["aID"];
    $vNaam = $_REQUEST["vNaam"];
    $aNaam = $_REQUEST["aNaam"];


    $conn = new mysqli($server, $user, $pwd, $database); 
	$sql = "update users set firstName='$vNaam', lastName='$aNaam' where UserID='$aID'";
    
    if (!($result = mysqli_query($conn, $sql))) {
	    echo "failed";
	}
	else {
	    echo 'success';
	}
?>