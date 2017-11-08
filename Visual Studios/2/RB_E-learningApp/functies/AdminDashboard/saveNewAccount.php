<?php
    $server = "localhost";
    $user = "root"; 
    $pwd = "";
    $database = "owl-learn";
    
    $vNaam = $_REQUEST["vNaam"];
    $aNaam = $_REQUEST["aNaam"];
    $gNaam = $_REQUEST["gNaam"];
    $ww = $_REQUEST["ww"];
    $rol = $_REQUEST["rol"];

    //Password encrypten
    $salt = dechex(mt_rand(0, 278317232)) . dechex(mt_rand(0, 278317232));
    $ww = hash('sha256', $ww.$salt);
    for($round = 0; $round < 65536; $round++){
        $ww = hash('sha256', $ww.$salt);
    }

    $conn = new mysqli($server, $user, $pwd, $database); 
	$sql = "insert into users (Username, Password, firstName, lastName, rolID, Salt) VALUES ('$gNaam', '$ww', '$vNaam', '$aNaam', '$rol', '$salt')";
    
    if (!($result = mysqli_query($conn, $sql))) {
	    echo "failed";
	}
	else {
	    echo 'success';
	}
?>