export interface AlertMessage {
  severity: AlertMessagesSeverity;
  summary?: string;
  detail: string;
  life?: number;
  key: string
}

export enum AlertMessagesSeverity {
  error = 'error',
  warn = 'warn',
  info = 'info',
  success = 'success',
}

export function getServerity(statusCode: number): AlertMessagesSeverity {

  if (statusCode === 426)
    return AlertMessagesSeverity.info;
  if (statusCode >= 500) {
    return AlertMessagesSeverity.error;
  } else if (statusCode >= 400) {
    return AlertMessagesSeverity.error;
  } else if (statusCode >= 200 && statusCode < 300) {
    return AlertMessagesSeverity.success;
  }
  else {
    return AlertMessagesSeverity.info;
  }
}

export function getSummary(statusCode: number): string {

  if (statusCode >= 500) {
    return "Something went wrong";
  } else if (statusCode >= 400) {
    return "Something went wrong";
  } else if (statusCode >= 200 && statusCode < 300) {
    return "Success";
  }
  else {
    return "Info";
  }
}

export function isUpgradeRequired(statusCode: number) {
  return statusCode === 426 ? "upgrade" : "default";
}
