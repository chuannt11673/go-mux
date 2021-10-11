<script>
export default {
  props: {
    question: {
      type: Object,
      require: true,
      default: null,
    },
  },
  data() {
    return {
      selectedChoiceId: null,
    }
  },
  methods: {},
}
</script>

<template>
  <div class="question">
    <div class="text">
      {{ question.text }}
    </div>
    <div v-for="(choice, cidx) in question.choices" :key="cidx" class="choices">
      <div class="choice">
        <input
          v-model="selectedChoiceId"
          :value="choice.choiceId"
          type="radio"
        />
        <label>{{ choice.text }}</label
        ><br />
      </div>
    </div>
  </div>
</template>

<style lang="scss">
@import '@design';
div.text {
  padding: 20px 0;
  font-size: 21px;
}
.choices {
  .choice {
    padding: 20px;
    border: 1px solid #ccc;
    border-radius: 10px;
    margin-bottom: 20px;
    font-size: 21px;
    label {
      margin-left: 10px;
    }
  }
}
</style>
