<?php
    $server = "localhost";
    $user = "root"; 
    $pwd = "";
    $database = "owl-learn";
    
    $conn = new mysqli($server, $user, $pwd, $database);
    $sql = "select * from `Vak`";

    $result = mysqli_query($conn, $sql);
    while ($rij = mysqli_fetch_array($result)) {
        echo $rij["Omschrijving"].".".$rij["VakID"].",";
    }
?>