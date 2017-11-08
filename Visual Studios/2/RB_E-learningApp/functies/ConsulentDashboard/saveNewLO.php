<?php
    $server = "localhost";
    $user = "root"; 
    $pwd = "";
    $database = "owl-learn";
    
    $loNaam = $_REQUEST["loNaam"];
    $vakID = $_REQUEST["vakid"];

    $conn = new mysqli($server, $user, $pwd, $database); 
	$sql = "insert into lesonderwerp (Omschrijving, VakID) VALUES ('$loNaam', '$vakID')";
    
    if (!($result = mysqli_query($conn, $sql))) {
	    echo "failed";
	}
	else {
	    echo 'success';
	}
?>