
<?php
    $server = "localhost";
    $user = "root"; 
    $pwd = "";
    $database = "owl-learn";
    
    $loID = $_REQUEST["loID"];

    $conn = new mysqli($server, $user, $pwd, $database); 
	$sql = "delete from lesonderwerp where LesonderwerpID=$loID";
    
    if (!($result = mysqli_query($conn, $sql))) {
	    echo "failed";
	}
	else {
	    echo 'success';
	}
?>