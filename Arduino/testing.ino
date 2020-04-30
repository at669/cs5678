#define pelt0 2
#define pelt1 3
#define pelt2 4
#define pelt3 5
const int piezoPin0 = A0; //reaction time
const int piezoPin1 = A1;
const int piezoPin2 = A2;
const int piezoPin3 = A3;
const int piezoPin4 = A4;
const int piezoPin5 = A5;
const int piezoPin6 = A6;
const int piezoPin7 = A7;
const int piezoPin8 = A8;
int heat[] = {0,50,100,200};
int stove0 = 0;
int stove1 = 0;
int stove2 = 0;
int stove3 = 0;
bool lastState0 = false;
bool lastState1 = false;
bool lastState2 = false;
bool lastState3 = false;
bool lastState4 = false;
bool lastState5 = false;
bool lastState6 = false;
bool lastState7 = false;
bool currentState0 = false;
bool currentState1 = false;
bool currentState2 = false;
bool currentState3 = false;
bool currentState4 = false;
bool currentState5 = false;
bool currentState6 = false;
bool currentState7 = false;
bool prev = false;
bool curr = false;
unsigned long prevTime = 0;
unsigned long currTime;

void setup()
{
  Serial.begin (9600);
  Serial.println("Start");
  analogWrite(pelt0, heat[0]);
  analogWrite(pelt1, heat[0]);
  analogWrite(pelt2, heat[0]);
  analogWrite(pelt3, heat[0]);
}
 
void loop()
{
  /*check analog inputs: piezos*/
  int piezo0 = analogRead(piezoPin0);
  int piezo1 = analogRead(piezoPin1);
  int piezo2 = analogRead(piezoPin2);
  int piezo3 = analogRead(piezoPin3);
  int piezo4 = analogRead(piezoPin4);
  int piezo5 = analogRead(piezoPin5);
  int piezo6 = analogRead(piezoPin6);
  int piezo7 = analogRead(piezoPin7);
  int piezo8 = analogRead(piezoPin8);
  // make piezos buttons
  // need debounce
  // keep track of each stove heat level 0,1,2,3
  //if clicking to increase past 3, decrease past 0, leave it at the extremes
  if (piezo0 > 0){
      //Serial.println("piezo0: ");
      //reaction time.. check when non zero to zero to non zero..
      curr = !curr;
      if (curr != prev) {
        currTime = millis();
        //Serial.println(currTime);
      }
      if (currTime-prevTime > 0) {
        Serial.println("reaction time (ms): ");
        Serial.println(currTime-prevTime);
      }
      prevTime = currTime;
      delay(50);
  }
  
  if (piezo1 > 5){
      currentState0 = !currentState0;
      //Serial.println("piezo1: ");
      if ((stove0 < 3)&&(currentState0 != lastState0)) {
      //only increments when it wasn't max heat
        stove0 = stove0 + 1;
        analogWrite(pelt3, heat[stove0]);
      }
      lastState0 = currentState0;
      //Serial.println(stove0);
      delay(100);
  }
  if (piezo2 > 5){
      currentState1 = !currentState1;
//      Serial.println("piezo2: ");
      if ((stove0 > 0)&&(currentState1 != lastState1)) {
        stove0 = stove0 - 1;
        analogWrite(pelt3, heat[stove0]);
      }
      lastState1 = currentState1;
      //Serial.println(stove0);
      delay(100);
  }
  if (piezo3 > 5){
      currentState2 = !currentState2;
      if (stove1 < 3) {
        stove1 = stove1 + 1;
        analogWrite(pelt2, heat[stove1]);
      }
      lastState2 = currentState2;
      delay(100);
  }
  if (piezo4 > 5){
      currentState3 = !currentState3;
      if (stove1 > 0) {
        stove1 = stove1 - 1;
        analogWrite(pelt2, heat[stove1]);
      }
      lastState3 = currentState3;
      delay(100);
  }
  if (piezo5 > 5){
      currentState4 = !currentState4;
      if (stove2 < 3) {
        stove2 = stove2 + 1;
        analogWrite(pelt0, heat[stove2]);
      }
      lastState4 = currentState4;
      delay(100);
  }
  if (piezo6 > 5){
      currentState5 = !currentState5;
      if (stove2 > 0) {
        stove2 = stove2 - 1;
        analogWrite(pelt0, heat[stove2]);
      }
      lastState5 = currentState5;
      delay(100);
  }
  if (piezo7 > 5){
      currentState6 = !currentState6;
      if (stove3 < 3) {
        stove3 = stove3 + 1;
        analogWrite(pelt1, heat[stove3]);
      }
      lastState6 = currentState6;
      delay(100);
  }
  if (piezo8 > 5){
      currentState7 = !currentState7;
      if (stove3 > 0) {
        stove3 = stove3 - 1;
        analogWrite(pelt1, heat[stove3]);
      }
      lastState7 = currentState7;
      delay(100);
  }
  
  /*do pwm: peltiers heat up/cool down*/
  // 0,1,2,3 no heat, 3 highest heat
  //test if peltiers work
}
