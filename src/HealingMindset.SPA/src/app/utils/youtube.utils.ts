export function extractYoutubeId(value: string): string {
  if (!value) return '';

  const regExp = /^.*(?:youtu\.be\/|v\/|u\/\w\/|embed\/|watch\?v=|shorts\/|&v=)([^#&?]*).*/;
  const match = value.match(regExp);

  return (match && match[1].length === 11) ? match[1] : value;
}