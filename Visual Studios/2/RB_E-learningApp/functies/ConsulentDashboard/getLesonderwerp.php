<?php
    $server = "localhost";
    $user = "root"; 
    $pwd = "";
    $database = "owl-learn";
    
    $vakID = $_REQUEST["vakID"];
    
    $conn = new mysqli($server, $user, $pwd, $database);
    $sql = "select * from `lesonderwerp` where `VakID` = '$vakID'";

    $result = mysqli_query($conn, $sql);
    while ($rij = mysqli_fetch_array($result)) {
        echo $rij["Omschrijving"].".".$rij["LesonderwerpID"].",";
    }
?>