
<?php
    $server = "localhost";
    $user = "root"; 
    $pwd = "";
    $database = "owl-learn";
    
    $planningid = $_REQUEST["pID"];

    $conn = new mysqli($server, $user, $pwd, $database); 
	$sql = "delete from toetsplanning where id=$planningid";
    
    if (!($result = mysqli_query($conn, $sql))) {
	    echo "failed";
	}
	else {
	    echo 'success';
	}
?>