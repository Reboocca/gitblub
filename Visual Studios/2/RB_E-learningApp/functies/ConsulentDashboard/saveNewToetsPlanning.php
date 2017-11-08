<?php
    $server = "localhost";
    $user = "root"; 
    $pwd = "";
    $database = "owl-learn";
    
    $leerlingid = $_REQUEST["uID"];
    $vakid = $_REQUEST["vID"];
    $datum = $_REQUEST["datum"];
    $loid = $_REQUEST["loid"];

    $conn = new mysqli($server, $user, $pwd, $database); 
	
    $sql1 = "select * from `lesonderwerp` where lesonderwerpID = '$loid'";

    $result1 = mysqli_query($conn, $sql1);
    while ($rij = mysqli_fetch_array($result1)) {
        $lonaam = $rij["Omschrijving"];

        $sql2 = "insert into toetsplanning (leerlingid, lesonderwerpid, datum, toetsnaam, VakID) VALUES ('$leerlingid', '$loid', '$datum', '$lonaam', '$vakid')";
        if (!($result2 = mysqli_query($conn, $sql2))) {
            echo "failed";
        }
        else {
            echo 'success';
        }
    }
    
?>