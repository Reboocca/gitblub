<?php
    $server = "localhost";
    $user = "root"; 
    $pwd = "";
    $database = "owl-learn";
    
    $leerlingid = $_REQUEST["uID"];
    $lesid = $_REQUEST["lesID"];
    $datum = $_REQUEST["datum"];

    $conn = new mysqli($server, $user, $pwd, $database); 
	
    $sql1 = "select * from `les` where lesID = '$lesid'";

    $result1 = mysqli_query($conn, $sql1);
    while ($rij = mysqli_fetch_array($result1)) {
        $lesnaam = $rij["lesNaam"];

        $sql2 = "insert into planning (leerlingid, lesid, datum, lesnaam) VALUES ('$leerlingid', '$lesid', '$datum', '$lesnaam')";
        if (!($result2 = mysqli_query($conn, $sql2))) {
            echo "failed";
        }
        else {
            echo 'success';
        }
    }
    
?>