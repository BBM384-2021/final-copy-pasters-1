<template>
  <div><SubClubPageHeader/></div>
    <div class="page">
      <h1 class=title>Join More Sub-Clubs</h1>
      <p>You can view the newly opened and the other sub-clubs below. 
        Right-click on the sub-club icons to learn more about them, click the icons to select the sub-clubs, and join after attending the questionnaire.</p>
      <div><NewSubClubsList/></div>
      <div><SubClubMenu/></div>
  </div>
  
</template>

<script>
import SubClubMenu from '@/components/Questionnaire/SubClubMenu.vue'
import NewSubClubsList from '@/components/Questionnaire/NewSubClubsList.vue'
import SubClubPageHeader from '@/components/SubClubPage/SubClubPageHeader.vue';

export default {
    name: 'JoinMoreSubClubs',
    components: {
        SubClubMenu,
        NewSubClubsList,
        SubClubPageHeader
  }
}
</script>

<style lang="scss" scoped>
  @import url('https://fonts.googleapis.com/css2?family=Alegreya+Sans:ital,wght@0,400;0,500;0,700;0,800;1,400;1,500;1,700&display=swap');
    :root{
    --primary-color: #BA7EA0;
    --bolder-color: #742957;
  }

  .page{
    padding:10%;
    padding-top:0;
    font-family: 'Alegreya Sans', sans-serif;
  }
  .title{
    color:black;
    font-size: 1.5em;
    padding: 3%;
    padding-left: 6%;
    margin:auto;
    font-weight: bold;
    
  }
  p{
    font-size: 1.2em;
    font-weight: 500;
    margin:0;
    padding-bottom: 3%;
  }
</style>