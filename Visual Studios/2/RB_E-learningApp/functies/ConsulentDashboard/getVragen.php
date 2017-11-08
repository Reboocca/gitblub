<?php
    $server = "localhost";
    $user = "root"; 
    $pwd = "";
    $database = "owl-learn";
    
    $lesID = $_REQUEST["lesID"];
    
    $conn = new mysqli($server, $user, $pwd, $database);
    $sql = "select * from `vragen` where `LesID` = '$lesID'";

    $result = mysqli_query($conn, $sql);
    while ($rij = mysqli_fetch_array($result)) {
        echo $rij["Vraag"]."^".$rij["VraagID"]."]";
    }
?>