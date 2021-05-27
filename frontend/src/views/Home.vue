<template>
    <div class="page">
      <div class="container">
            <a href="#" class="logo">Interest Club</a>
            <a href="#" class="About">About</a>
            <a href="#" class="LogIn" @click="goToSignIn()">Sign In</a>
            <a href="#" class="SignUp" @click="goToSignUp()">Sign Up</a>
      </div>
      <div class="main">
        <div class="center">
          <h1>Union of Interests</h1>
          <h2>The best platform to find people<br>with the same interests as you.<br></h2>
        </div>
      </div>
      
      
    </div>
</template>

<script>
// @ is an alias to /src
export default {
  name: "Home",
  methods: {
    goToSignIn(){
      this.$router.push({path: "/sign_in"});
    },
    goToSignUp(){
      this.$router.push({path: "/sign_up"});
    }
  },
  components: {
    
  },
};
</script>

<style scoped lang="scss">
  @import url('https://fonts.googleapis.com/css2?family=Alegreya+Sans:ital,wght@0,400;0,500;0,700;0,800;1,400;1,500;1,700&display=swap');
  :root{
      --primary-color: #BA7EA0;
      --bolder-color: #742957;
  }
  .page{
    background-image: url("~@/assets/background.jpeg");
    background-size: 100% 100%;
  }
  .container{
    max-height: 90px;
    margin: 0;
    padding: 1.2em;
    display:grid;
    grid-template-columns: 30% auto 15% 10% 10%;
    grid-template-rows: 2em;
    column-gap: 2%;
    font-family: 'Alegreya Sans', sans-serif;
    align-items: center;
    background: rgba($color: white, $alpha: 0.7);
    
  }
  .logo{
    text-decoration: none;
    font-weight: 800;
    color: #742957;
    font-size: 2em;
    justify-self: center;
  }

  a{
    color:#742957;
    text-decoration: none;
    font-size: 1em;
    font-weight: 700;
  }
  
  .About{
    color:rgb(51, 50, 51);
    grid-column: 3;
    justify-self: end;
    padding-right: 1em;
  }
  .LogIn {
    background: white;
    border-radius: 1em;
    padding:0.2em 1em;
    grid-column: 4;
    justify-self: center;

  }
  .SignUp {
    background: #742957;
    color: white;
    border-radius: 1em;
    padding:0.2em 1em;
    grid-column: 5;
    justify-self: start;

  }
  .SignUp:hover{
    background: plum;
    border-radius: 1em;
    
  }
  .LogIn:hover{
    background: plum;
    border-radius: 1em;
    
  }
  .main{
    height: auto;
    display: grid;
    grid-template-columns: 1fr 3fr 1fr;
    grid-template-rows:1fr 2fr 2fr ;
  }
  .center{
    grid-column-start: 2;
    grid-row-start: 2;
    
  }
  .center{
    background: rgba($color: #ffffff, $alpha: 0.8);
    border-radius: 5em;
    border:0.2em solid black;
    font-family: 'Alegreya Sans', sans-serif;
    text-align: center;
    
    h1{
      font-size: 5em;
      margin:0;
      padding:.6em .5em;
      padding-bottom: .3em;
    }

    h2{
      font-size: 2em;
      margin:0;
      padding:1.2em .5em;
      padding-top: 0;
    }
  
  }
  @media screen and (max-width:800px){
    .center {
      h1{
        font-size: 250%;
      }
      h2{
        font-size: 150%;
      }
    }
  }
  @media only screen and (min-width: 768px){
    .container .logo{
        font-size: 1.8em;
    }
    a{
        font-size: 1.2em;
        font-weight: 500;
    }
}

@media only screen and (min-width: 1024px){
    .container .logo{
        font-size: 2.2em;
    }
    a{
        font-size: 1.4em;
    }
}
</style>
