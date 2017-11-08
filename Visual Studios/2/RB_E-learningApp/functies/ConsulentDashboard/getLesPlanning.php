<?php
    $server = "localhost";
    $user = "root"; 
    $pwd = "";
    $database = "owl-learn";
    
    $uID = $_REQUEST["uID"];

    $conn = new mysqli($server, $user, $pwd, $database);
    $sql = "select * from `planning` where leerlingid = '$uID'";

    $result = mysqli_query($conn, $sql);
    while ($rij = mysqli_fetch_array($result)) {
        echo $rij["id"]."^".$rij["lesnaam"]."]";
    }
?>