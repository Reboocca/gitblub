<?php
    $server = "localhost";
    $user = "root"; 
    $pwd = "";
    $database = "owl-learn";
    
    $userid = $_REQUEST["uID"];
    $datum = $_REQUEST["datum"];

    $conn = new mysqli($server, $user, $pwd, $database);
    $sql = "select * from `planning` where `datum` = '$datum' and `leerlingid` = '$userid'";

    $result = mysqli_query($conn, $sql);

    $x=0;
	$response=array();
    while ($rij = mysqli_fetch_array($result)) {
        $response[$x]["PlanningOmschrijving"] = $rij["lesnaam"];
        $response[$x]["PlanningID"] = $rij["id"];
        $response[$x]["LesID"] = $rij["lesid"];

        $x++;
    }

	echo json_encode($response, JSON_UNESCAPED_UNICODE);
	mysqli_close($conn);
?>