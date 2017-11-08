<?php
    $server = "localhost";
    $user = "root"; 
    $pwd = "";
    $database = "owl-learn";
    
    $vraag = $_REQUEST["vraag"];
    $lesid = $_REQUEST["lesid"];
    $loid = $_REQUEST["loid"];
    $A = $_REQUEST["A"];
    $B = $_REQUEST["B"];
    $C = $_REQUEST["C"];
    $D = $_REQUEST["D"];
    $juist = $_REQUEST["juist"];

    $conn = new mysqli($server, $user, $pwd, $database); 
	$sql = "insert into vragen (Vraag, LesID, LesonderwerpID) VALUES ('$vraag', '$lesid', '$loid')";
    
    if (!($result = mysqli_query($conn, $sql))) {
	    echo "failed";
	}
	else {
	    $sql1 = "Select * from vragen where vraag='$vraag' and LesID ='$lesid' and LesonderwerpID = '$loid'";
        $result1 = mysqli_query($conn, $sql1);
        while ($rij = mysqli_fetch_array($result1)) {
            $vraagid = $rij["VraagID"];
            $sql2 = null;
            switch($juist){
                case "1":
                    $sql2 = "insert into antwoorden(VraagID, Antwoord, Juist_Onjuist) VALUES('$vraagid', '$A', '1'), ('$vraagid', '$B', '2'), ('$vraagid', '$C', '2'), ('$vraagid', '$D', '2')";
                    break;
                case "2":
                    $sql2 = "insert into antwoorden(VraagID, Antwoord, Juist_Onjuist) VALUES('$vraagid', '$A', '2'), ('$vraagid', '$B', '1'), ('$vraagid', '$C', '2'), ('$vraagid', '$D', '2')";
                    break;
                case "3":
                    $sql2 = "insert into antwoorden(VraagID, Antwoord, Juist_Onjuist) VALUES('$vraagid', '$A', '2'), ('$vraagid', '$B', '2'), ('$vraagid', '$C', '1'), ('$vraagid', '$D', '2')";
                    break;
                case "4":
                    $sql2 = "insert into antwoorden(VraagID, Antwoord, Juist_Onjuist) VALUES('$vraagid', '$A', '2'), ('$vraagid', '$B', '2'), ('$vraagid', '$C', '2'), ('$vraagid', '$D', '1')";
                    break;
            }
            if (!($result2 = mysqli_query($conn, $sql2))) {
                echo "failed";
            }
            else{
                echo "succes";
            }
        }    
    }

?>