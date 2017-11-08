<?php
    $server = "localhost";
    $user = "root"; 
    $pwd = "";
    $database = "owl-learn";
    
    $loID = $_REQUEST["loID"];
    
    $conn = new mysqli($server, $user, $pwd, $database);
    $sql = "SELECT * FROM `vragen` WHERE `LesonderwerpID` = '$loID'";

    $result = mysqli_query($conn, $sql);
    while ($rij = mysqli_fetch_array($result)) {
        echo $rij["Vraag"]."^".$rij["VraagID"]."]";
    }
?>