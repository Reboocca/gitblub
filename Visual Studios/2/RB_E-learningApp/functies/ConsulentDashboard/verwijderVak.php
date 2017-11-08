<?php
    $server = "localhost";
    $user = "root"; 
    $pwd = "";
    $database = "owl-learn";
    
    $vakID = $_REQUEST["vakID"];

    $conn = new mysqli($server, $user, $pwd, $database); 
	$sql = "delete from vak where VakID=$vakID";
    
    if (!($result = mysqli_query($conn, $sql))) {
	    echo "failed";
	}
	else {
	    echo 'success';
	}
?>