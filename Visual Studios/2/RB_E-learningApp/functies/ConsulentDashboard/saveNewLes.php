<?php
    $server = "localhost";
    $user = "root"; 
    $pwd = "";
    $database = "owl-learn";
    
    $lNaam = $_REQUEST["lNaam"];
    $Uitleg = $_REQUEST["Uitleg"];
    $loID = $_REQUEST["loid"];

    $conn = new mysqli($server, $user, $pwd, $database); 
	$sql = "insert into les (lesNaam, Uitleg, LesonderwerpID) VALUES ('$lNaam', '$Uitleg', '$loID')";
    
    if (!($result = mysqli_query($conn, $sql))) {
	    echo "failed";
	}
	else {
	    echo 'success';
	}
?>