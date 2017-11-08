<?php
    $server = "localhost";
    $user = "root"; 
    $pwd = "";
    $database = "owl-learn";
    
    $vNaam = $_REQUEST["vNaam"];

    $conn = new mysqli($server, $user, $pwd, $database); 
	$sql = "insert into vak (Omschrijving) VALUES ('$vNaam')";
    
    if (!($result = mysqli_query($conn, $sql))) {
	    echo "failed";
	}
	else {
	    echo 'success';
	}
?>