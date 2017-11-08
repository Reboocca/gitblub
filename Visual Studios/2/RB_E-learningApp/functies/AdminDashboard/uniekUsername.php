<?php
    $server = "localhost";
    $user = "root"; 
    $pwd = "";
    $database = "owl-learn";
    
    $username = $_REQUEST["uname"];
    
    $conn = new mysqli($server, $user, $pwd, $database);
    $sql = "select * from `users` where `Username` = '$username'";

    $result = mysqli_query($conn, $sql);
    if ($rij = mysqli_fetch_array($result)) {
        echo "Bestaat";    
    }
    else {
        echo "Uniek";
    }
?>