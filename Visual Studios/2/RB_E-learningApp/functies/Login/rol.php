<?php
    $server = "localhost";
    $user = "root"; 
    $pwd = "";
    $database = "owl-learn";
    
    $rolID = "false";

    $userid = $_REQUEST["id"];

    
    $conn = new mysqli($server, $user, $pwd, $database);
    $sql = "select * from `users` where UserID='$userid'";
    $result = mysqli_query($conn, $sql);
    if ($rij = mysqli_fetch_array($result)) {
        echo $rij["rolID"];
    }
?>