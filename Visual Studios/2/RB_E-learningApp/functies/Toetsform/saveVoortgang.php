<?php
    $server = "localhost";
    $user = "root"; 
    $pwd = "";
    $database = "owl-learn";
    
    $loID = $_REQUEST["loID"];
    $uID = $_REQUEST["uID"];
    $score = $_REQUEST["score"];

    $conn = new mysqli($server, $user, $pwd, $database);
	$sql = "insert into toetsresultaten (UserID, LesonderwerpID, Resultaat) VALUES ('$uID', '$loID', '$score')";
	
    if (!($result = mysqli_query($conn, $sql))) {
	    echo "failed";
	}
	else {
	    echo 'success';
	}
?>