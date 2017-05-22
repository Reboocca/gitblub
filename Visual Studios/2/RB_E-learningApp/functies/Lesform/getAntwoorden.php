<?php
    $server = "localhost";
    $user = "root"; 
    $pwd = "";
    $database = "owl-learn";
    
    $vID = $_REQUEST["vID"];
    
    $conn = new mysqli($server, $user, $pwd, $database);
    $sql = "SELECT * FROM `antwoorden` WHERE `VraagID` = '$vID'";

    $result = mysqli_query($conn, $sql);
    while ($rij = mysqli_fetch_array($result)) {
        echo $rij["Antwoord"].".".$rij["AntwoordID"].",";
    }
?>