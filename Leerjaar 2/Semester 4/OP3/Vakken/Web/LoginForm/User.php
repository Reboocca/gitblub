<?php
    class User{
     public $firstname;
     public $lastname;
     public $role;     
     public $place;
     public $username;
     public $pwd;
     public $salt;

        public function __construct(){
            $this->getSalt();
        }

        public function getInfo($getFirstname, $getLastname, $getRole, $getPlace, $getUsername, $getPwd){
            $this->firstname=$getFirstname;
            $this->lastname=$getLastname;
            $this->role=$getRole;
            $this->place=$getPlace;
            $this->username=$getUsername;
            $this->pwd=$getPwd;

            $this->securePwd(); 
        }

        public function getSalt(){
            $this->salt = dechex(mt_rand(0, 278317232)) . dechex(mt_rand(0, 278317232));
        }

        public function securePwd(){
            $this->pwd = hash('sha256', $this->pwd.$this->salt);
            echo $this->pwd."</br>";

            for($round = 0; $round < 65536; $round++){
                $this->pwd = hash('sha256', $this->pwd.$this->salt);
            }
            echo $this->pwd;
        }
    }
?>