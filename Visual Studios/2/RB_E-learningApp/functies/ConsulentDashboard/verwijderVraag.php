
<?php
    $server = "localhost";
    $user = "root"; 
    $pwd = "";
    $database = "owl-learn";
    
    $vraagID = $_REQUEST["vraagID"];

    $conn = new mysqli($server, $user, $pwd, $database); 
	$sql = "delete from vragen where vraagID=$vraagID";
    
    if (!($result = mysqli_query($conn, $sql))) {
	    echo "failed";
	}
	else {
	    $sql1 = "delete from antwoorden where vraagID=$vraagID";
        if (!($result = mysqli_query($conn, $sql))) {
	    echo "failed";
	    }
        else{
            echo "succes";
        }
	}
?>