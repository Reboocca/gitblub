
<?php
    $server = "localhost";
    $user = "root"; 
    $pwd = "";
    $database = "owl-learn";
    
    $accountID = $_REQUEST["aID"];

    $conn = new mysqli($server, $user, $pwd, $database); 
	$sql = "delete from users where UserID=$accountID";
    
    if (!($result = mysqli_query($conn, $sql))) {
	    echo "failed";
	}
	else {
	    echo 'success';
	}
?>