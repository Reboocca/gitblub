<?php
    $server = "localhost";
    $user = "root"; 
    $pwd = "";
    $database = "owl-learn";
    
    $lID = $_REQUEST["lID"];
    
    $conn = new mysqli($server, $user, $pwd, $database);
    $sql = "SELECT * FROM `les` WHERE `LesID` = '$lID'";

    $result = mysqli_query($conn, $sql);
    while ($rij = mysqli_fetch_array($result)) {
        echo $rij["lesNaam"];
    }
?>