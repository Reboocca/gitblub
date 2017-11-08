<?php
    $server = "localhost";
    $user = "root"; 
    $pwd = "";
    $database = "owl-learn";

    $username = $_REQUEST["user"];
    $password = $_REQUEST["pwd"];
    $checkpassword; 

    $conn = new mysqli($server, $user, $pwd, $database);
    $sql = "select * from `users` where Username='$username'";
    $result = mysqli_query($conn, $sql);
    
    if ($rij = mysqli_fetch_array($result)) {
        $checkpassword = hash('sha256', $password.$rij["Salt"]);
        for($round = 0; $round < 65536; $round++){
            $checkpassword = hash('sha256', $checkpassword.$rij["Salt"]);
        }
        
        if ($rij['Password']==$checkpassword) {
            echo $rij["UserID"];
        }
        else {
            echo "false";
        }
    }
    else{
        echo "false";
    }
?>