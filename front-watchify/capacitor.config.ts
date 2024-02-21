import { CapacitorConfig } from '@capacitor/cli';

const config: CapacitorConfig = {
  appId: 'com.watchify',
  appName: 'watchify',
  webDir: 'www',
  server: {
    androidScheme: 'https'
  }
};

export default config;
