<?php
    $server = "localhost";
    $user = "root"; 
    $pwd = "";
    $database = "owl-learn";
    
    $aID = $_REQUEST["aID"];
    $uNaam = $_REQUEST["uNaam"];
    $ww = $_REQUEST["ww"];

    $salt = dechex(mt_rand(0, 278317232)) . dechex(mt_rand(0, 278317232));
    $ww = hash('sha256', $ww.$salt);
    for($round = 0; $round < 65536; $round++){
        $ww = hash('sha256', $ww.$salt);
    }


    $conn = new mysqli($server, $user, $pwd, $database); 
	$sql = "update users set Password='$ww', Username='$uNaam', Salt='$salt' where UserID='$aID'";
    if (!($result = mysqli_query($conn, $sql))) {
	    echo "failed";
	}
	else {
	    echo 'success';
	}
?>