<?php
    $server = "localhost";
    $user = "root"; 
    $pwd = "";
    $database = "owl-learn";
    
    $conn = new mysqli($server, $user, $pwd, $database);
    $sql = "select * from `users` where rolID = 2";

    $result = mysqli_query($conn, $sql);
    while ($rij = mysqli_fetch_array($result)) {
        echo $rij["UserID"].".".$rij["firstName"]." ".$rij["lastName"].",";
    }
?>