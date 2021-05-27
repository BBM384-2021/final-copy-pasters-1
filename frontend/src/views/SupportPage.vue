<template>
    <div><SubClubPageHeader/></div>
      <div class="support_page">
      <h1 class=title>Support Page</h1>
      <div><SendRequest/></div>
      </div>
</template>

<script>
import SendRequest from '@/components/Support/SendRequest.vue';
import SubClubPageHeader from '@/components/SubClubPage/SubClubPageHeader.vue';
export default {
    name: 'SupportPage',
    components:{
        SendRequest,
        SubClubPageHeader
    },
    
}
</script>

<style lang="scss" scoped>
    @import url('https://fonts.googleapis.com/css2?family=Alegreya+Sans:ital,wght@0,400;0,500;0,700;0,800;1,400;1,500;1,700&display=swap');
    :root{
        --primary-color: #BA7EA0;
        --bolder-color: #742957;
    }

    .support_page{
        padding:10%;
        padding-top:0;
        font-family: 'Alegreya Sans', sans-serif;
    }
    .title{
        color:black;
        font-size: 1.6em;
        padding: 6%;
        padding-left: 8%;
        padding-bottom:4%;
        margin:auto;
        font-weight: bold;
    }

</style>