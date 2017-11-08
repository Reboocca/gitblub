<?php
    $server = "localhost";
    $user = "root"; 
    $pwd = "";
    $database = "owl-learn";
    
    $vNaam = $_REQUEST["vNaam"];
    
    $conn = new mysqli($server, $user, $pwd, $database);
    $sql = "select * from `vak` where `Omschrijving` = '$vNaam'";

    $result = mysqli_query($conn, $sql);
    if ($rij = mysqli_fetch_array($result)) {
        echo "Bestaat";    
    }
    else {
        echo "Uniek";
    }
?>