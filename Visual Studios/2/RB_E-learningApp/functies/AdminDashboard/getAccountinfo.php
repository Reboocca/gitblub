<?php
    $server = "localhost";
    $user = "root"; 
    $pwd = "";
    $database = "owl-learn";
    
    $accountID = $_REQUEST["aID"];
    
    $conn = new mysqli($server, $user, $pwd, $database);
    $sql = "select * from `users` where `UserID` = '$accountID'";

    $result = mysqli_query($conn, $sql);
    while ($rij = mysqli_fetch_array($result)) {
        echo $rij["firstName"].".".$rij["lastName"].".".$rij["Username"];
    }
?>