<template>
    <h2 class="text">New Sub-Clubs</h2>
    <div class="new_sub_clubs_container">
        <ul class="menu">
              <li v-for="sub_club in $store.state.new_sub_clubs" :key="sub_club.name">
                  <input type="checkbox" :id="sub_club.name" :value="sub_club"/>
                  <label :for="sub_club.name" @click="$store.commit('addSubClub',sub_club)"><img :src="require('@/assets/'+sub_club.name+'_mini.jpeg')" /></label>
                  <div class="sub-club-name"> {{sub_club.name}}</div> 
              </li>
        </ul>
    </div>
    <h2 class="text">Other Sub-Clubs</h2>
</template>

<script>
export default {

}
</script>

<style lang="scss" scoped>
    .text{
        color:var(--primary-color);
        font-size: 1.5em;
        margin-left: 15%;
    }

    .new_sub_clubs_container{
        background-color: #f1f1f1;
        border-radius: 10px;
        width:50%;
        margin:auto;
        display: flex;
        flex-wrap: wrap;
        justify-content:start;
        padding:10px;
    }

  .menu{
        padding-left: 1%;
        margin: 0;
        display: flex;
        flex-wrap: wrap;
        justify-content: center;
    }

    li {
        display:flex;
        flex-direction:column;
        justify-content: center;

        .sub-club-name {      
            font-size: 1.2em;
            position:relative;
            display: flex;
            justify-content: center;
            margin-bottom: 20px;
            
        }
    }

    input[type="checkbox"] {
        display: none;
    }

    label {
    border: 1px solid #f1f1f1;
    margin: 10px;
    padding: 10px;
    display: block;
    position: relative;
    cursor: pointer;
    -webkit-touch-callout: none;
    -webkit-user-select: none;
    -khtml-user-select: none;
    -moz-user-select: none;
    -ms-user-select: none;
    user-select: none;
    }

    label img {
    height: 5em;
    width: 5em;
    transition-duration: 0.2s;
    transform-origin: 50% 50%;
    border-radius: 10px;
    }

    label::before {
    background-color: white;
    color: white;
    content: " ";
    display: block;
    border-radius: 50%;
    border: 1px solid grey;
    position: absolute;
    top: -5px;
    left: -5px;
    width: 25px;
    height: 25px;
    text-align: center;
    line-height: 28px;
    transition-duration: 0.4s;
    transform: scale(0);
    }

    :checked+label {
    border-color: #ddd;
    border-radius: 10px;
    }

    :checked+label::before {
    content: "✓";
    background-color: grey;
    transform: scale(1);
    
    }

    :checked+label img {
    transform: scale(0.9);
    box-shadow: 0 0 5px #333;
    z-index: -1;
    }
</style>