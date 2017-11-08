<?php
    $server = "localhost";
    $user = "root"; 
    $pwd = "";
    $database = "owl-learn";
    
    $loID = $_REQUEST["loID"];
    
    $conn = new mysqli($server, $user, $pwd, $database);
    $sql = "select * from `les` where `LesonderwerpID` = '$loID'";

    $result = mysqli_query($conn, $sql);
    while ($rij = mysqli_fetch_array($result)) {
        echo $rij["lesNaam"].".".$rij["LesID"].",";
    }
?>