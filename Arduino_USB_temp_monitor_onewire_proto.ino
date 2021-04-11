#include <OneWire.h>
#include <DallasTemperature.h>

// Data wire is plugged into digital pin 2 on the Arduino
#define ONE_WIRE_BUS 2

// Setup a oneWire instance to communicate with any OneWire device
OneWire oneWire(ONE_WIRE_BUS);

// Pass oneWire reference to DallasTemperature library
DallasTemperature sensors(&oneWire);

int deviceCount = 0;
float tempC;
// variable to hold device addresses
DeviceAddress Thermometer;


void setup(void)
{

  Serial.begin(115200);
}

void loop(void)
{
  deviceCount = 0;
  sensors.begin();  // Start up the library
  deviceCount = sensors.getDeviceCount();
  sensors.requestTemperatures();

  for (int i = 0;  i < deviceCount;  i++)
  {
    Thermometer == NULL;
    Serial.print("S");
    Serial.print(i + 1);
    Serial.print(":");
    sensors.getAddress(Thermometer, i);
    printAddress(Thermometer);
    Serial.print(":");
    tempC = sensors.getTempCByIndex(i);
    Serial.print(tempC);
    //Serial.print((char)176);//shows degrees character
    Serial.print(":");
    Serial.print(DallasTemperature::toFahrenheit(tempC));
    //Serial.print((char)176);//shows degrees character
    Serial.println("");
  }
}


void printAddress(DeviceAddress deviceAddress)
{
  for (uint8_t i = 0; i < 8; i++)
  {
    Serial.print("0x");
    if (deviceAddress[i] < 0x10) Serial.print("0");
    Serial.print(deviceAddress[i], HEX);
    if (i < 7) Serial.print(",");
  }
}
