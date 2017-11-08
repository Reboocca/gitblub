
<?php
    $server = "localhost";
    $user = "root"; 
    $pwd = "";
    $database = "owl-learn";
    
    $lesID = $_REQUEST["lesID"];

    $conn = new mysqli($server, $user, $pwd, $database); 
	$sql = "delete from les where LesID=$lesID";
    
    if (!($result = mysqli_query($conn, $sql))) {
	    echo "failed";
	}
	else {
	    echo 'success';
	}
?>