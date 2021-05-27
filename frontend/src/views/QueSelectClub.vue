<template>
  <div>
    <SubClubSelectionHeader/>
  </div>
  <div class="page">
    <h1 class=title>What are your interests?</h1>
    <p>You can find sub-clubs by clicking on the categories in the menu. Please select at least one sub-club according to your interests. After you finish your selection, you will be applied the questionnaire based on the sub-clubs you chose.</p>
    <div>  
      <SubClubMenu/>
    </div>
  </div>
  
</template>

<script>
// @ is an alias to /src
import SubClubMenu from '@/components/Questionnaire/SubClubMenu.vue'
import SubClubSelectionHeader from '@/components/Questionnaire/SubClubSelectionHeader.vue'

export default {
  name: 'QueSelectClub',
  components: {
    SubClubMenu,
    SubClubSelectionHeader
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
  }
  .title{
    font-family: 'Alegreya Sans', sans-serif;
    color:black;
    font-size: 1.5em;
    padding: 2%;
    padding-left: 7%;
    margin:auto;
    font-weight: bold;
    
  }
  p{
    font-family: 'Alegreya Sans', sans-serif;
    font-size: 1.2em;
    font-weight: 500;
    margin:0;
    padding-bottom: 2.5%;
  }

</style>