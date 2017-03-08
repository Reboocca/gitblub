<!DOCTYPE html>
<?php
	session_start();
	include_once 'DBSclass.php';
    include_once 'User.php';
    $database = new dbs();
?>
<html class="full" lang="en">
	<head>
		<title>Overwatch</title>
		<meta charset="UTF-8">
		<link href="css/bootstrap.css" rel="stylesheet">
		<link href="css/inlog.css" rel="stylesheet">
		<script src="https://use.fontawesome.com/9b27a3d5a2.js"></script>
		<script src="https://ajax.googleapis.com/ajax/libs/jquery/1.12.4/jquery.min.js"></script>
	</head>
	<body>
		<div class="container">
			<div class=" vertical-center-login col-md-offset-3 col-md-6 col-xs-offset-1 col-xs-10 login">
				<div class="row" style="background: #ff9c59;">
					<h1>
						Dasboard
						<?php
							//echo $_SESSION['userid']."SDSDF";
							//$database->getUser($_SESSION['userid'])
						?>
					</h1>
				</div>
					<div class="row lead">You've succesfully logged in!</div>
				
				<i class="fa fa-check-circle" aria-hidden="true" style="color: #96d69e; font-size: 150px; margin-top:15px; margin-bottom: 25px;"></i></br>
				
				<button type="button" style=" margin-bottom: 40px;" onclick="window.location.href='sessiondestroy.php'">Back to the login page</button>
				
			</div>
		</div>
		<script src="js/main.js"></script>
	</body>
</html>