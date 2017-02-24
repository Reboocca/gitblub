<!DOCTYPE html>
<html class="full" lang="en">
	<head>
		<title>Overwatch</title>
		<meta charset="UTF-8">
		<link href="css/bootstrap.css" rel="stylesheet">
		<link href="css/inlog.css" rel="stylesheet">
		<script src="https://ajax.googleapis.com/ajax/libs/jquery/1.12.4/jquery.min.js"></script>
	</head>
	<body>
		<?php
			$login_try= false;
			$username_try;
		?>
		<div class="container">
			<div class=" vertical-center col-md-offset-2 col-md-8 col-xs-offset-1 col-xs-10 login">
				<div class="row">
					<br/>
					<h1>
						Welcome to Overwatch
					</h1>
				</div>
				<p class="row lead">
					A place for all heroes
				</p>
				<form class="row form" action="" method="POST">
					<div class="col-xs-10 col-xs-offset-1" style="margin-bottom: 10px;">
						<div class="row">
							<div class="col-xs-12 form-group">
								<input type="text" name="gbr" placeholder="Username" required/>	
							</div>
						</div>
						<div class="row">
							<div class="col-xs-12 form-group">
								<input type="password" name="ww" placeholder="Password" required/>	
							</div>
						</div>
					</div>
					<br/>
					<br/>
					<button type="submit" name="Login">Login</button>
					<br/>
					<p style="margin-top: 20px; margin-bottom: 20px; fontsize: 12px;">No account? You can register over <a href="Register.php">here</a>!</p>
					<?php
						if(isset($_POST) && isset($_POST['Login'])){
							$username_try = $_POST['gbr'];		
							include 'DBSclass.php';
							$newlogin = new dbs();
							$newlogin->login( $_POST['gbr'], md5($_POST['ww']));
							
						}
					?>
				</form>
			</div>
		</div>
		<script src="js/main.js"></script>
	</body>
</html>