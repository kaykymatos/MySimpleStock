import toast from "react-hot-toast";

export const showAlert = (type:'success'|'error'|'warning', message:string) => {
    switch (type) {
      case "success":
        toast.success(message);
        break;
      case "error":
        toast.error(message);
        break;
      case "warning":
        toast(message, {
          icon: "⚠️",
          style: {
            background: "#fbbf24",
            color: "#fff",
          },
        });
        break;
      default:
        toast(message);
    }
  };