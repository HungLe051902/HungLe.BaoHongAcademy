<template>
  <div id="about">
    About

    <input type="text" name="" value="" />

    <ion-button color="primary">Primary</ion-button>
    <ion-button color="secondary">Secondary</ion-button>
    <ion-button color="tertiary">Tertiary</ion-button>
    <ion-button color="success">Success</ion-button>
    <ion-button color="warning">Warning</ion-button>
    <ion-button color="danger">Danger</ion-button>
    <ion-button color="light">Light</ion-button>
    <ion-button color="medium">Medium</ion-button>
    <ion-button color="dark">Dark</ion-button>

    <ion-item>
      <ion-label>Select</ion-label>
      <ion-select>
        <ion-select-option value="brown">Brown</ion-select-option>
        <ion-select-option value="blonde">Blonde</ion-select-option>
        <ion-select-option value="black">Black</ion-select-option>
        <ion-select-option value="red">Red</ion-select-option>
      </ion-select>
    </ion-item>
  </div>
</template>
<script>
import { IonButton, IonItem, IonLabel, IonSelect, IonSelectOption } from "@ionic/vue";
import { defineComponent } from "vue";
export default defineComponent({
  components: { IonButton, IonItem, IonLabel, IonSelect, IonSelectOption },
});
</script>
<style lang="scss" scoped></style>
