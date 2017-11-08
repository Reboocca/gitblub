<?php
    $server = "localhost";
    $user = "root"; 
    $pwd = "";
    $database = "owl-learn";
    
    $vakID = $_REQUEST["vakID"];
    $datum = $_REQUEST["datum"];
    
    $conn = new mysqli($server, $user, $pwd, $database);
    $sql = "select * from `toetsplanning` where `VakID` = '$vakID' and `datum` <= '$datum'";

    $result = mysqli_query($conn, $sql);
    while ($rij = mysqli_fetch_array($result)) {
        echo $rij["toetsnaam"].".".$rij["lesonderwerpid"].",";
    }
?>