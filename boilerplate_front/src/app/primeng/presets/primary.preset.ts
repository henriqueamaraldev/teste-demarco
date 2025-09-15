import { definePreset } from '@primeng/themes';
import Aura from '@primeng/themes/aura';

export const MyPreset = definePreset(Aura, {
  semantic: {
    primary: {
      50: "#f5f5f8",
      100: "#cdcdde",
      200: "#a5a5c5",
      300: "#7d7dab",
      400: "#555691",
      500: "#2d2e77",
      600: "#262765",
      700: "#1f2053",
      800: "#191941",
      900: "#121230",
      950: "#0b0c1e"
    },
    colorScheme: {
      light: {
        text: {
          color: '#111928',
          mutedColor: '#5A6476'
        }
      }
    }
  }
});
