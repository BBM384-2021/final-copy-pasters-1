<template>
    <div><SubClubPageHeader/></div>
    <div class="container">
        <div class="info">
            Your request has been delivered! You will be informed after your request is evaluated.
        </div>
        <div class="return_button">
            <button class="return" @click="()=>$router.push('/entry_page')"> Go Back to Home Page</button>
        </div>
    </div>
  
</template>

<script>
import SubClubPageHeader from '@/components/SubClubPage/SubClubPageHeader.vue';
export default {
    components:{
        SubClubPageHeader
    },
}
</script>

<style lang="scss" scoped>
    @import url('https://fonts.googleapis.com/css2?family=Alegreya+Sans:ital,wght@0,400;0,500;0,700;0,800;1,400;1,500;1,700&display=swap');
    .container {
        font-family: 'Alegreya Sans', sans-serif;
        margin:10% 30%;
        display:flex;
        flex-direction: column;
        justify-content: center;
        align-items: center;
    }
    .info{
        padding:20px;
        text-align: center;
        font-size: 1.8em;
    }

    .return_button{
        margin-top: 15px;
    }
    
    .return{
        background-color: #BA7EA0;
        color: white;
        cursor: pointer;
        padding: 5px;
        width: 250px;
        height:80px;
        border: .1px solid white;
        text-align: center;
        outline: none;
        transition: 0.4s;
        text-decoration: none;
        font-size: 1.2em;
        border-radius: 10px;
        font-weight: 500;
    }

</style>