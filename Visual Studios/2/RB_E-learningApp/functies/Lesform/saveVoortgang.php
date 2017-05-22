<?php
    $server = "localhost";
    $user = "root"; 
    $pwd = "";
    $database = "owl-learn";
    
    $lID = $_REQUEST["lID"];
    $uID = $_REQUEST["uID"];
    $loID = null;
    
    $conn = new mysqli($server, $user, $pwd, $database);
    $sql1 = "SELECT * FROM `les` WHERE `LesID` = '$lID'";

    $result1 = mysqli_query($conn, $sql1);
    while ($rij = mysqli_fetch_array($result1)) {
        $loID = $rij["LesonderwerpID"];
    }
    
	$sql2 = "insert into voortgang (UserID, LesID, LesonderwerpID, Voortgang) VALUES ('$uID', '$lID', '$loID', 1)";
	
    if (!($result2 = mysqli_query($conn, $sql2))) {
	    echo "failed";
	}
	else {
	    echo 'success';
	}
?>