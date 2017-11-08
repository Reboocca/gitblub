<?php
    $server = "localhost";
    $user = "root"; 
    $pwd = "";
    $database = "owl-learn";
    
    $antwoord = $_REQUEST["antwoord"];
    $vID = $_REQUEST["vID"];
    
    $conn = new mysqli($server, $user, $pwd, $database);
    $sql = "Select Juist_onjuist FROM `antwoorden` WHERE VraagID = '$vID' AND `Antwoord` = '$antwoord'";

    $result = mysqli_query($conn, $sql);
    while ($rij = mysqli_fetch_array($result)) {
        echo $rij["Juist_onjuist"];
    }
?>